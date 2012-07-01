namespace BookStore.Core.Extensions.Paging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize, int? totalCount)
        {
            this.Initialize(source.AsQueryable(), index, pageSize, totalCount);
        }

        public PagedList(IQueryable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            this.Initialize(source, index, pageSize, totalCount);
        }

        public int PageCount
        {
            get;
            private set;
        }

        public int TotalItemCount
        {
            get;
            private set;
        }

        public int PageIndex
        {
            get;
            private set;
        }

        public int PageNumber
        {
            get
            {
                return this.PageIndex + 1;
            }
        }

        public int PageSize
        {
            get;
            private set;
        }

        public bool HasPreviousPage
        {
            get;
            private set;
        }

        public bool HasNextPage
        {
            get;
            private set;
        }

        public bool IsFirstPage
        {
            get;
            private set;
        }

        public bool IsLastPage
        {
            get;
            private set;
        }

        protected void Initialize(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            ///### argument checking
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("PageIndex cannot be below 0.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("PageSize cannot be less than 1.");
            }

            ///### set source to blank list if source is null to prevent exceptions
            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            ///### set properties
            if (!totalCount.HasValue)
            {
                this.TotalItemCount = source.Count();
            }

            this.PageSize = pageSize;
            this.PageIndex = index;

            if (this.TotalItemCount > 0)
            {
                this.PageCount = (int)Math.Ceiling(this.TotalItemCount / (double)this.PageSize);
            }
            else
            {
                this.PageCount = 0;
            }

            this.HasPreviousPage = this.PageIndex > 0;

            this.HasNextPage = this.PageIndex < (this.PageCount - 1);
            this.IsFirstPage = this.PageIndex <= 0;
            this.IsLastPage = this.PageIndex >= (this.PageCount - 1);

            ///### add items to internal list
            if (this.TotalItemCount > 0)
            {
                AddRange(source.Skip((index) * pageSize).Take(pageSize).ToList());
            }
        }
    }
}