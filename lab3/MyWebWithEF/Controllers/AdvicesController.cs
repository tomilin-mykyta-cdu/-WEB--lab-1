using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class AdvicesController : ControllerBase
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

    [HttpPost]
    public async Task<ActionResult<AdviceDto>> CreateDevice(AdviceEditDto model)
    {
        var advice = await _adviceService.CreateDevice(model);

        await _context.SaveChangesAsync();

        var adviceDto = _mapper.Map<AdviceDto>(advice);
        return Ok(adviceDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDevice(int id, AdviceEditDto model)
    {
        model.Id = id;

        var advice = _adviceService.UpdateAdvice(model);

        await _context.SaveChangesAsync();

        var updatedAdvice = _adviceService.GetAdviceByIdAsync(id);

        return Ok(updatedAdvice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdvice(int id)
    {
        var deleted = _adviceService.DeleteAdvice(id);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
