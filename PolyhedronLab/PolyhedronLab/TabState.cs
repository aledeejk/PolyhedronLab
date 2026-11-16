using System.Collections.Generic;

namespace PolyhedronLab
{
    // Полный снимок состояния вкладки
    public class TabSnapshot
    {
        public Matrix4x4 ModelMatrix;
        public Polyhedron Poly;       // геометрия на момент снимка
        public object BuildParams;    // параметры построения (ось, функция и т.п.)

        public TabSnapshot Clone() => new TabSnapshot
        {
            ModelMatrix = ModelMatrix,
            Poly = Poly,
            BuildParams = BuildParams
        };
    }

    public class TabState
    {
        public Matrix4x4 ModelMatrix { get; set; } = Matrix4x4.Identity();

        // История полных снимков (для Undo)
        public Stack<TabSnapshot> History { get; } = new Stack<TabSnapshot>();

        // Самый первый снимок — для Reset
        public TabSnapshot InitialSnapshot { get; set; }

        // Кладём текущее состояние в историю, затем применяем операцию к матрице
        public void PushAndApply(Matrix4x4 op, bool applyLocally, Polyhedron poly, object buildParams)
        {
            History.Push(new TabSnapshot
            {
                ModelMatrix = ModelMatrix,
                Poly = poly,
                BuildParams = buildParams
            });
            ModelMatrix = applyLocally ? ModelMatrix * op : op * ModelMatrix;
        }

        // Просто зафиксировать текущее состояние в истории (перед сменой фигуры/параметров)
        public void PushSnapshot(Polyhedron poly, object buildParams)
        {
            History.Push(new TabSnapshot
            {
                ModelMatrix = ModelMatrix,
                Poly = poly,
                BuildParams = buildParams
            });
        }

        // Откат на предыдущий снимок. Возвращает снимок, к которому откатились, либо null.
        public TabSnapshot Undo()
        {
            if (History.Count == 0) return null;
            var snap = History.Pop();
            ModelMatrix = snap.ModelMatrix;
            return snap;
        }
    }
}