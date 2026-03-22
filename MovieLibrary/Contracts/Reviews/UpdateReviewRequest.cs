namespace Movie_Library.Contracts.Reviews;

public record UpdateReviewRequest(
    string Comment,
    int Rating);
