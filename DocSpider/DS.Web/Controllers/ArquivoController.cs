using AutoMapper;
using DS.Business.DTO.Arquivos;
using DS.Business.Interface.Service;
using DS.Web.Models;
using HeyRed.Mime;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Web.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly IArquivoService _arquivoService;
        private readonly IMapper Mapper;

        public ArquivoController(IArquivoService arquivoService, IMapper mapper)
        {
            _arquivoService = arquivoService;
            Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int? pagina)
        {
            var listArquivos = await _arquivoService.Listar(pagina ?? 1);

            var result = Mapper.Map<List<ArquivoDetalheSemBlobViewModel>>(listArquivos.Data);
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArquivoCadastroViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            
            try
            {
                var result = Mapper.Map<ArquivoCadastroDTO>(viewModel);
                result.Dados = viewModel.Arquivo;

                await _arquivoService.Novo(result);

                TempData["mensagem"] = "Cadastro efetuado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["erro"] = "Não foi possível cadastrar o Arquivo!";
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            try
            {
                var arquivoDTO = await _arquivoService.BuscaCompletaPorId(Id);

                if (arquivoDTO != null)
                {
                    var viewModel = Mapper.Map<ArquivoCadastroViewModel>(arquivoDTO);
                    return View(viewModel);
                }
                else
                {
                    TempData["erro"] = "Não foi possível encontrar o arquivo com esse identificados!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                TempData["erro"] = "Erro ao buscar o Arquivo!";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            try
            {
                var arquivoDTO = await _arquivoService.BuscaCompletaPorId(Id);

                if (arquivoDTO != null)
                {
                    var viewModel = Mapper.Map<ArquivoDetalheViewModel>(arquivoDTO);
                    return View(viewModel);
                }
                else
                {
                    TempData["erro"] = "Não foi possível encontrar o arquivo com esse identificador!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Erro ao buscar o Arquivo!";
                return RedirectToAction(nameof(Index));
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var arquivoDTO = await _arquivoService.BuscaCompletaPorId(Id);

                if (arquivoDTO != null)
                {
                    await _arquivoService.Excluir(Id);
                    TempData["mensagem"] = "Cadastro excluído com sucesso!";
                    return View();
                }
                else
                {
                    TempData["erro"] = "Não foi possível encontrar o arquivo com esse identificador!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Erro ao excluir o Arquivo!";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArquivoCadastroViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["mensagem"] = "Dados inválidos!";
                return View(viewModel);
            }        
            
            try
            {
                var arquivoBuscaDTO = await _arquivoService.BuscaCompletaPorId(viewModel.Id);

                if (arquivoBuscaDTO != null)
                {
                    var arquivoDTO = Mapper.Map<ArquivoAtualizarDTO>(viewModel);
                    arquivoDTO.Dados = viewModel.Arquivo;

                    await _arquivoService.Atualizar(arquivoDTO);
                    
                    TempData["mensagem"] = "Cadastro atualizado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["erro"] = "Não foi possível encontrar o arquivo com esse identificados!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Erro ao buscar o Arquivo!";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<FileResult> Download(Guid Id)
        {
            var viewModel = await _arquivoService.BuscaCompletaPorId(Id);

            var file =  File(viewModel.Dados, MimeTypesMap.GetMimeType(viewModel.Nome), string.Concat(viewModel.Nome, Path.GetExtension(viewModel.Nome)));
            return file;
        }

    
    }
}
