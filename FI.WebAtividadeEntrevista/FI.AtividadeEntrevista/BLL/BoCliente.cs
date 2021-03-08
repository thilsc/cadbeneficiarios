using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Cliente cliente)
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();

            return cliDAO.Incluir(cliente);
        }

        /// <summary>
        /// Inclui os beneficiários de um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>        
        public void IncluirBeneficiarios(DML.Cliente cliente)
        {
            DAL.DaoBeneficiario benefDAO = new DAL.DaoBeneficiario();
            foreach (var benef in cliente.Beneficiarios)
            {
                benef.IdCliente = cliente.Id;
                benefDAO.Incluir(benef);
            }
        }

    /// <summary>
    /// Altera um cliente
    /// </summary>
    /// <param name="cliente">Objeto de cliente</param>
    public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            DAL.DaoBeneficiario benefDAO = new DAL.DaoBeneficiario();

            cliDAO.Alterar(cliente);

            foreach (var benef in cliente.Beneficiarios)
                benefDAO.Alterar(benef);
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            return cliDAO.Consultar(id);
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            ExcluirBeneficiarios(id);

            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            cliDAO.Excluir(id);
        }

        /// <summary>
        /// Exclui os beneficiários de um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>        
        public void ExcluirBeneficiarios(long IdCliente)
        {
            DAL.DaoBeneficiario benefDAO = new DAL.DaoBeneficiario();

            var cli = Consultar(IdCliente);

            foreach (var benef in cli.Beneficiarios)
                benefDAO.Excluir(benef.Id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            return cliDAO.Listar();
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            return cliDAO.Pesquisa(iniciarEm,  quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoCliente cliDAO = new DAL.DaoCliente();
            return cliDAO.VerificarExistencia(CPF);
        }
    }
}
