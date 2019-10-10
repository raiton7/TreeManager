using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreeManager.Models;

namespace TreeManager.Database
{
    public class NodeRepository
    {
        private readonly NodeContext nodeContext;

        public NodeRepository()
        {
            nodeContext = new NodeContext();
        }

        public void Add(Node node)
        {
            nodeContext.Node.Add(node);
            nodeContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Node nodeToDelete = nodeContext.Node.Find(id);
            nodeContext.Node.Remove(nodeToDelete);
            nodeContext.SaveChanges();
        }

        public void Update(Node node)
        {
            Node nodeToUpdate = nodeContext.Node.SingleOrDefault(nU => nU.Id == node.Id);
            if (nodeToUpdate != null)
            {
                nodeToUpdate.IdParent = node.IdParent;
                nodeToUpdate.Value = node.Value;
            }
            nodeContext.SaveChanges();
        }

        public IEnumerable<Node> FindAll()
        {
            return nodeContext.Node.ToList();
        }

        public Node FindById(int id)
        {
            return nodeContext.Node.Find(id);
        }
    }
}