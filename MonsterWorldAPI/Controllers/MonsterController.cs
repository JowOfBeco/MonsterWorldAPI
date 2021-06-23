using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterWorldAPI.API;
using MonsterWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonsterWorldAPI.Services;

namespace MonsterWorldAPI.Controllers
{
    [Route("api/[controller]")] //Define controller para inicio
    [ApiController]
    public class MonsterController : ControllerBase
    {
        MonsterServices monstersFilled = new();
        

        [HttpPost] // Metodo de criação utilizando solicitação com preenchimento no corpo da mesma.
        public IActionResult Create([FromBody] Monster m)
        {
            var exists = monstersFilled.AddMonster().FirstOrDefault(monst => monst.Name == m.Name);


            return exists == null ? // Código para retorno de resposta para a solicitação, padronizado via classe APIResponse.
                Ok(new APIResponse<Monster>() { Succeed = true, Message = "Monstro criado com sucesso", Results = m }) :
                NotFound(new APIResponse<string>() { Succeed = false, Message = "Monstro já existe." });
        }
        [HttpGet]//Leitura sem itens passados no corpo da solicitação ou tipo de variavel como ID, retorna todos.
        public IActionResult List() => Ok(new APIResponse<List<Monster>>() { Succeed = true, Results = monstersFilled.AddMonster() });

        [HttpGet]
        [Route("{Id}")] //Get utilizando id para buscar o monstro.
        public IActionResult Get(int? id)
        {
            var exists = monstersFilled.AddMonster().FirstOrDefault(m => m.Id == id);
            return exists == null ?
                NotFound(new APIResponse<string>() { Succeed = false, Message = "Monstro não existe" }) :
                Ok(new APIResponse<Monster>() { Succeed = true, Results = exists });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Monster monst)
        {
            var exists = monstersFilled.AddMonster().FirstOrDefault(m => m.Id == monst.Id);
            return exists == null ?
                NotFound(new APIResponse<string>() { Succeed = false, Message = "Monstro não existe" }) :
                Ok(new APIResponse<Monster>() { Succeed = true, Message = "Monstro atualizado com sucesso", Results = exists });
        }
        [HttpDelete] // Delete
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            var exists = monstersFilled.AddMonster().FirstOrDefault(m => m.Id == id);
            return exists == null ?
                NotFound(new APIResponse<string>() { Succeed = false, Message = "Monstro não existe" }) :
                Ok(new APIResponse<string>() { Succeed = true, Message = "Monstro deletado com sucesso" });
        }
    }
}
