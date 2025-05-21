using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;

public class TransferService : ITransferService
{    private readonly IClubService _clubService;
    private readonly IHotwheelsService _hotwheelsService;
    private readonly IUserService _userService;
    public TransferService(IClubService clubService,IHotwheelsService hotwheelsService,IUserService userService)
    {
        _clubService = clubService;
        _hotwheelsService = hotwheelsService;
        _userService = userService;
    }

    // public Task<HotwheelsModel> TransferHotwheels(HotwheelsModel hotwheels, int id)
    // {
    //     //  _hotwheelsService.Update(, id);
    // }

    public Task<HotwheelsModel> TransferMembers(HotwheelsModel hotwheels, int id)
    {
        throw new NotImplementedException();
    }
}