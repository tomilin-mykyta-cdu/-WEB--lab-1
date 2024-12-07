using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MyWebWithEF.Controllers.Customer.Base
{
    public class AdvicesController : CustomerApiController
    {
        private readonly AdviceService _adviceService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdvicesController(AdviceService commentService, ApplicationDbContext context, IMapper mapper)
        {
            _adviceService = commentService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdviceDto>>> GetAdvices()
        {
            var advices = await _adviceService.GetAllAdvicesAsync();
            var advicesDto = _mapper.Map<List<AdviceDto>>(advices);
            return Ok(advicesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdviceDto>> DetAdvice(int id)
        {
            var advice = await _adviceService.GetAdviceByIdAsync(id);
            if (advice == null)
            {
                return NotFound();
            }

            var adviceDto = _mapper.Map<AdviceDto>(advice);
            return Ok(adviceDto);
        }
    }
}
