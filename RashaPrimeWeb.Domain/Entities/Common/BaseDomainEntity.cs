namespace RashaPrimeWeb.Domain.Entities.Common
{
    public abstract class BaseDomainEntity
    {

        public int Id { get; set; }
        //public DateTime? DateCreated { get; set; }
        //public string? CreatedBy { get; set; }
        //public string? Owner { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
        //public string? LastModifiedBy { get; set; }
        public bool Status { get; set; } = true; 
        public bool IsDeleted { get; set; } = true;
    }
}
