using API.DTOs;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountsController(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userManager.FindUserByEmailFromClaimsAsync(HttpContext.User);

            if (user != null)
                return Ok(new UserDTO
                {
                    DisplayName = user.FirstName,
                    Token = await _tokenService.GenerateToken(user)
                });
            else return NotFound();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("details")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetails()
        {
            var user = await _userManager.FindUserByEmailFromClaimsWithAddressAsync(HttpContext.User);

            return _mapper.Map<UserDetailsDTO>(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return Ok(new UserDTO
            {
                DisplayName = user.FirstName,
                Token = await _tokenService.GenerateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            if (!register.Password.Equals(register.ConfirmedPassword)) return BadRequest("Passwords don't match");

            if (await _userManager.FindByEmailAsync(register.Email) != null) return BadRequest("Email already exists");

            var user = new User
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded) return BadRequest();

            await _userManager.AddToRoleAsync(user, "User");

            return Created("", new UserDTO
            {
                DisplayName = user.FirstName,
                Token = await _tokenService.GenerateToken(user)
            });

        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDTO>> GetUserAddress()
        {
            var user = await _userManager.FindUserByEmailFromClaimsWithAddressAsync(HttpContext.User);

            return _mapper.Map<AddressDTO>(user.Address);
        }

        [Authorize]
        [HttpPost("updateAddress")]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO newAddress)
        {
            var user = await _userManager.FindUserByEmailFromClaimsWithAddressAsync(HttpContext.User);

            user.Address = _mapper.Map<Address>(newAddress);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<AddressDTO>(user.Address));

            return BadRequest("problem updating the user address");
        }
    }
}
