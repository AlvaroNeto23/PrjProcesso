using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrjProcesso.ViewModels;
using PrjProcesso.Models;
using PrjProcesso.Repositories.Interfaces;

namespace PrjProcesso.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly IProcessoRepository _processoRepository;
        private readonly IMapper _mapper;

        public ProcessoController(IProcessoRepository processoRepository, IMapper mapper)
        {
            _processoRepository = processoRepository;
            _mapper = mapper;
        }
        
        //Index com Paginação
        public async Task<IActionResult> Index(int? pageNumber, int pageSize = 10)
        {
            var processos = await _processoRepository.GetAllAsync();

            var orderedProcessos = processos.OrderBy(p => p.DataCadastro);

            int currentPage = pageNumber ?? 1;
            var paginatedList = orderedProcessos
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["CurrentPage"] = currentPage;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)processos.Count() / pageSize);

            var viewModel = _mapper.Map<IEnumerable<ProcessoViewModel>>(paginatedList);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var processo = await _processoRepository.GetByIdAsync(id);
            if (processo == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ProcessoViewModel>(processo);

            //----------Preenchendo a Data de Visualização automaticamente
            processo.DataVisualizacao = DateTime.Now;
            _processoRepository.Update(processo);
            await _processoRepository.SaveAsync();
            //----------

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var processo = _mapper.Map<Processo>(viewModel);
                processo.Id = Guid.NewGuid();

                //-----Preenchendo a Data do cadastro
                processo.DataCadastro = DateTime.Now;

                await _processoRepository.AddAsync(processo);
                await _processoRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var processo = await _processoRepository.GetByIdAsync(id);
            if (processo == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ProcessoViewModel>(processo);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProcessoViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var processo = _mapper.Map<Processo>(viewModel);
                _processoRepository.Update(processo);
                await _processoRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var processo = await _processoRepository.GetByIdAsync(id);
            if (processo == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ProcessoViewModel>(processo);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _processoRepository.DeleteAsync(id);
            await _processoRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
