namespace MultiShop.DTOLayer.DTOs.CommentDTOs
{
    public record CreateCommentDTO
    {
        public Guid CommentID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public string ProductID { get; set; }
        public string ImageUrl { get; set; }
    }
}