using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGrpc.Models
{
	public class ChatRoom
	{
		public int Id { get; }
		public List<Customer> CustomersInRoom { get; }
		public ChatRoom(int id)
		{
			Id = id;
			CustomersInRoom = new List<Customer>();
		}
	}
}
