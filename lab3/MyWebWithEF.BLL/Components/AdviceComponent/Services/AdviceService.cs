using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class AdviceService
{
    private readonly ApplicationDbContext _context;

    public AdviceService(ApplicationDbContext context)
    {
        _context = context;
    }

   
    public async Task<List<Advice>> GetAllAdvicesAsync()
    {
        return await _context.Advices.ToListAsync();
    }

  
    public async Task<Advice?> GetAdviceByIdAsync(int id)
    {
        return await _context.Advices.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Advice> CreateDevice(AdviceEditDto model)
    {
        var advice = new Advice
        {
            Value = model.Value,
            Domain = model.Domain,
        };

        _context.Advices.Add(advice);
        return advice;
    }

    public Advice UpdateAdvice(AdviceEditDto adviceEdit)
    {
        var advice = _context.Advices.Find(adviceEdit.Id);
        if (advice == null)
        {
            throw new Exception("Advices is not found");
        }

        advice.Value = advice.Value;
        advice.Domain = advice.Domain;

        return advice;
    }

    public bool DeleteAdvice(int id)
    {
        var adviceInstance = _context.Advices.Find(id);
        if (adviceInstance == null)
        {
            throw new Exception("Advice is not found");
        }

        _context.Advices.Remove(adviceInstance);
        return true;
    }
}
