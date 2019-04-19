namespace TraktSharp.Structs {

	/// <summary>Settings for pagination on supporting request types</summary>
	public struct TraktPaginationOptions {

		/// <summary>Default constructor</summary>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		public TraktPaginationOptions(int? page, int? limit) {
			Page = page;
			Limit = limit;
		}

		/// <summary>The page number</summary>
		public int? Page;

		/// <summary>The number of records to show per page</summary>
		public int? Limit;

	}

}