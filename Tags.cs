using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VEngine
{
	class Tags
	{
		public string tagName { get; set; }
		public string tagContent { get; set; }
		public List<tg> tagProperties = new List<tg>();
		public List<tg> tagChildren = new List<tg>();
	}
	class tg
	{
		public string name { get; set; }
		public string content { get; set; }
	}
}
