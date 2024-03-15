using BlazorMaterializeNet8.Components.Components;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorMaterializeNet8.Components
{
    public class RzFilter
    {
        public string Valor {  get; set; }
    }

    public class RzFilterGroup
    {
        public List<RzFilter> RzFilters { get; set; } = new();

        public RzFilterGroup(List<object> Lista) 
        {
            foreach (object obj in Lista)
            {
                AddItemToList(obj);
            }
        }

        public string SerializarRzFilters()
        {
            return JsonSerializer.Serialize(RzFilters);
        }

        private void AddItemToList(object obj)
        {
            if (obj is InputTeste1)
            {
                AddInputTeste1 (obj as InputTeste1);
            }

            if (obj is InputTeste2)
            {
                AddInputTeste2 (obj as InputTeste2);
            }
        }

        private void AddInputTeste1(InputTeste1 obj)
        {
            if(obj.Visivel == true)
            {
                this.RzFilters.Add(new RzFilter { Valor = obj.Valor.ToString() });
            }
        }

        private void AddInputTeste2(InputTeste2 obj)
        {
            if (obj.Visivel == true)
            {
                this.RzFilters.Add(new RzFilter { Valor = obj.Valor });
            }
        }
    }
}
