using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCommon.Model
{
	public class Message
	{
		public Command Command { get; set; }
		public int Id { get; set; }
		public int? FromUserId { get; set; }
		public int? ToUserId { get; set; }
		public string? Text { get; set; }
		public virtual User? FromUser { get; set; }
		public virtual User? ToUser { get; set; }
		public bool Received { get; set; }
	}
}
