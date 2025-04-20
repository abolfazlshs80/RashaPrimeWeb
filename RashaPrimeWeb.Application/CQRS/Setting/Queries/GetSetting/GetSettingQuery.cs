using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

public record GetSettingQuery() : IRequest<GetSettingDto>;