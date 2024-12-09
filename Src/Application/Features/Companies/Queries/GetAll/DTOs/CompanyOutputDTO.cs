namespace Application.Features.Companies.Queries.GetAll.DTOs;

public record CompanyDTO(Guid Id, string Name, string Email, string BranchAddress);

public record CompanyOutputDTO(List<CompanyDTO> Companies, int Total, int PageSize, int CurrentPage);