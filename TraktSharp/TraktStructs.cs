using System;
using System.Linq;

namespace TraktSharp {

	public struct PaginationOptions {
		public PaginationOptions(int? page, int? limit) { Page = page; Limit = limit; }
		public int? Page;
		public int? Limit;
	}

}