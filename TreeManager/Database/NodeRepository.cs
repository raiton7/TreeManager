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

        public void Dispose()
        {
            nodeContext.Dispose();
        }

        public void CascadeDeleteById(int id)
        {
            Node nodeToDelete = nodeContext.Node.Find(id);
            List<Node> nodes = nodeToDelete.ChildNodes.ToList();
            int nodesCountToDelete = nodeToDelete.ChildNodes.Count;
            if (nodeToDelete.ChildNodes.Count > 0)
            {
                for (int i = 0; i < nodesCountToDelete; i++)
                {
                    CascadeDeleteById(nodes[i].Id);
                }   
            }
            if (nodeToDelete.ChildNodes.Count == 0)
            {
                DeleteById(nodeToDelete.Id);
            }
        }
    }
}