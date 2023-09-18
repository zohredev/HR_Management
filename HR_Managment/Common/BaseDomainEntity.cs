namespace HR_Managment.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
