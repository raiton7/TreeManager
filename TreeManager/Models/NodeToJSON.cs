using System.Collections.Generic;

namespace TreeManager.Models
{
    public class NodeToJSON
    {
        public string text { get; set; }
        public List<NodeToJSON> children { get; set; }
        public State state { get; set; } = new State();
    }

    public class State
    {
        public string opened { get; set; } = "true";
    }
}