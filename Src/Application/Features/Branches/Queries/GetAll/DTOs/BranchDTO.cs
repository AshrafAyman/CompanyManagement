namespace Application.Features.Branches.Queries.GetAll.DTOs;

public record BranchDTO(Guid Id, string BranchAddress);
public record BranchOutputDTO(List<BranchDTO> Branches, int Total, int PageSize, int CurrentPage);