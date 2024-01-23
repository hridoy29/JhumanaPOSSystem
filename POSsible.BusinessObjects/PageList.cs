using System;
using System.Text;

namespace POSsible.BusinessObjects
{
	[Serializable()]
	public class PageList
	{
		public Int32  PageId { get; set; } 
		public Int32 ParentId { get; set; }
        public string  PageTitle { get; set; }
		public string  PageName { get; set; }
		public string  Description { get; set; }
		public string  PageUrl { get; set; }
		public string  ImageUrl { get; set; }
		public Int32  ModuleId { get; set; }
		public bool  IsPage { get; set; }
		public bool  IsRemoved { get; set; }
		public DateTime  CreateDate { get; set; }
		public Int32  CreatorId { get; set; }

		public PageList()
		{ }

		public PageList(Int32 PageId,Int32 ParentId,string PageTitle,string PageName,string Description,string PageUrl,string ImageUrl,Int32 ModuleId,bool IsPage,bool IsRemoved,DateTime CreateDate,Int32 CreatorId)
		{
			this.PageId = PageId;
            this.ParentId = ParentId;
			this.PageTitle = PageTitle;
			this.PageName = PageName;
			this.Description = Description;
			this.PageUrl = PageUrl;
			this.ImageUrl = ImageUrl;
			this.ModuleId = ModuleId;
			this.IsPage = IsPage;
			this.IsRemoved = IsRemoved;
			this.CreateDate = CreateDate;
			this.CreatorId = CreatorId;
		}

		public override string ToString()
		{
			return "PageId = " + PageId.ToString() + ",PageTitle = " + PageTitle + ",PageName = " + PageName + ",Description = " + Description + ",PageUrl = " + PageUrl + ",ImageUrl = " + ImageUrl + ",ModuleId = " + ModuleId.ToString() + ",IsPage = " + IsPage.ToString() + ",IsRemoved = " + IsRemoved.ToString() + ",CreateDate = " + CreateDate.ToString() + ",CreatorId = " + CreatorId.ToString();
		}

	}
}
