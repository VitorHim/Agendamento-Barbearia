using Agendamento_Barbearia;
using System.Linq;

namespace BarbeariaFlow
{
    internal class Program
    {
        static List<Barbeiro> barbeiros = new List<Barbeiro>();
        static int proximoId = 1;

        static List<Servico> servicos = new List<Servico>();

        static int proximoIdServico = 1;

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

            static void MenuPrincipal()
            {
                int opcao = 0;

                do
                {
                    Console.WriteLine("\n======== BARBEARIA FLOW ========");
                    Console.WriteLine("1 - Gerenciar barbeiros");
                    Console.WriteLine("2 - Agendar um horário");
                    Console.WriteLine("3 - Catálogo de serviços");
                    Console.WriteLine("0 - Sair");

                    Console.Write("\nOpção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Digite uma opção válida.");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            MenuBarbeiros();
                            break;

                        case 2:
                            AgendarHorario();
                            break;
                        
                        case 3:
                            CatalogoServicos();
                            break;

                        case 0:
                            Console.WriteLine("Encerrando sistema...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }

                } while (opcao != 0);
            }

            static void MenuBarbeiros()
            {
                int opcao = 0;

                do
                {
                    Console.WriteLine("\n======== GERENCIAMENTO DE BARBEIROS ========");
                Console.WriteLine("1 - Cadastrar barbeiro");
                Console.WriteLine("2 - Listar barbeiros");
                Console.WriteLine("3 - Editar barbeiro");
                Console.WriteLine("4 - Excluir ou desativar barbeiro");  
                Console.WriteLine("0 - Voltar");

                Console.Write("\nOpção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Digite uma opção válida.");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            CadastrarBarbeiro();
                            break;

                        case 2:
                            ListarBarbeiros();
                            break;
                        case 3:
                            EditarBarbeiro();
                            break;
                        case 4:
                            GerenciarSituacaoBarbeiro();
                        break;
                        case 0:
                            Console.WriteLine("Voltando ao menu principal...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }

                } while (opcao != 0);
            }

            static void CatalogoServicos()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("\n======== CATÁLOGO DE SERVIÇOS ========");
                Console.WriteLine("1 - Cadastrar serviço");
                Console.WriteLine("2 - Listar serviços");
                Console.WriteLine("3 - Editar serviço");
                Console.WriteLine("4 - Excluir ou desativar serviço");
                Console.WriteLine("0 - Voltar");

                Console.Write("\nOpção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite uma opção válida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarServico();
                        break;

                    case 2:
                        ListarServicos();
                        break;

                    case 3:
                        EditarServico();
                        break;

                    case 4:
                        GerenciarSituacaoServico();
                        break;

                    case 0:
                        Console.WriteLine("Voltando ao menu principal...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }

            static void CadastrarServico()
            {
                Servico novoServico = new Servico();

                novoServico.Id = proximoIdServico++;

                Console.Write("\nNome do serviço: ");
                novoServico.Nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(novoServico.Nome))
                {
                    Console.WriteLine("O nome do serviço não pode ficar vazio.");
                    return;
                }

                Console.Write("Preço do serviço: R$ ");

                if (!decimal.TryParse(Console.ReadLine(), out decimal preco) || preco < 0)
                {
                    Console.WriteLine("Digite um preço válido.");
                    return;
                }

                novoServico.Preco = preco;
                novoServico.Ativo = true;

                servicos.Add(novoServico);

                Console.WriteLine("\nServiço cadastrado com sucesso!");
                Console.WriteLine($"ID: {novoServico.Id}");
                Console.WriteLine($"Nome: {novoServico.Nome}");
                Console.WriteLine($"Preço: R$ {novoServico.Preco:F2}");
            }   
            
            static void ListarServicos()
        {
            Console.WriteLine("\n--- Lista de Serviços ---");
            if (servicos.Count == 0)
            {
                Console.WriteLine("Nenhum serviço cadastrado.");
                return;
            }
            foreach (var servico in servicos)
            {
                Console.WriteLine($"ID: {servico.Id}, Nome: {servico.Nome}, Preço: R$ {servico.Preco:F2}, Ativo: {servico.Ativo}");
            }
        }

            static void EditarServico()
        {
            Console.Write("\nDigite o ID do serviço: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Servico servico = servicos.FirstOrDefault(s => s.Id == id);

            if (servico == null)
            {
                Console.WriteLine("Serviço não encontrado.");
                return;
            }

            Console.WriteLine($"\nServiço encontrado: {servico.Nome}");

            Console.Write("Novo nome: ");
            servico.Nome = Console.ReadLine();

            Console.Write("Novo preço: R$ ");
            if (decimal.TryParse(Console.ReadLine(), out decimal novoPreco) && novoPreco >= 0)
            {
                servico.Preco = novoPreco;
            }
            else
            {
                Console.WriteLine("Preço inválido.");
            }

            Console.WriteLine("\nServiço atualizado com sucesso!");
        }
            
            static void GerenciarSituacaoServico()
        {
            Console.Write("\nDigite o ID do serviço: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Servico servico = servicos.FirstOrDefault(s => s.Id == id);
            if (servico == null)
            {
                Console.WriteLine("Serviço não encontrado.");
                return;
            }
            Console.WriteLine($"\nServiço encontrado: {servico.Nome}");
            Console.WriteLine("1 - Ativar serviço");
            Console.WriteLine("2 - Desativar serviço");
            Console.WriteLine("3 - Excluir serviço");
            Console.WriteLine("0 - sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    servico.Ativo = true;
                    Console.WriteLine("\nServiço ativado com sucesso!");
                    break;
                case 2:
                    servico.Ativo = false;
                    Console.WriteLine("\nServiço desativado com sucesso!");
                    break;
                case 3:
                    servicos.Remove(servico);
                    Console.WriteLine("\nServiço excluído com sucesso!");
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

            static void CadastrarBarbeiro()
            {


                Barbeiro novoBarbeiro = new Barbeiro();

                novoBarbeiro.Id = proximoId++;

                Console.Write("Nome do barbeiro: ");
                novoBarbeiro.Nome = Console.ReadLine();

                Console.Write("Telefone: ");
                novoBarbeiro.Telefone = Console.ReadLine();

                novoBarbeiro.Ativo = true;

                barbeiros.Add(novoBarbeiro);

                Console.Clear();
                Console.WriteLine("\nBarbeiro cadastrado com sucesso!");
                Console.WriteLine($"ID: {novoBarbeiro.Id}");
        }

            static void ListarBarbeiros()
            {
                Console.WriteLine("\n--- Lista de Barbeiros ---");
                if (barbeiros.Count == 0)
                {
                    Console.WriteLine("Nenhum barbeiro cadastrado.");
                    return;
                }
                foreach (var barbeiro in barbeiros)
                {
                    Console.WriteLine($"ID: {barbeiro.Id}, Nome: {barbeiro.Nome}, Telefone: {barbeiro.Telefone}, Ativo: {barbeiro.Ativo}");
                }
            }

            static void EditarBarbeiro()
        {
            Console.Write("\nDigite o ID do barbeiro: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Barbeiro barbeiro = barbeiros.FirstOrDefault(b => b.Id == id);

            if (barbeiro == null)
            {
                Console.WriteLine("Barbeiro não encontrado.");
                return;
            }

            Console.WriteLine($"\nBarbeiro encontrado: {barbeiro.Nome}");

            Console.Write("Novo nome: ");
            barbeiro.Nome = Console.ReadLine();

            Console.Write("Novo telefone: ");
            barbeiro.Telefone = Console.ReadLine();

            Console.WriteLine("\nBarbeiro atualizado com sucesso!");
        }

            static void GerenciarSituacaoBarbeiro()
            {
                Console.Write("\nDigite o ID do barbeiro: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                Barbeiro barbeiro = barbeiros.FirstOrDefault(b => b.Id == id);

                if (barbeiro == null)
                {
                    Console.WriteLine("Barbeiro não encontrado.");
                    return;
                }

                Console.WriteLine($"\nBarbeiro encontrado: {barbeiro.Nome}");

                Console.WriteLine("1 - Ativar barbeiro");
                Console.WriteLine("2 - Desativar barbeiro");
                Console.WriteLine("3 - Excluir barbeiro");
                Console.WriteLine("0 - sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        barbeiro.Ativo = true;
                        Console.WriteLine("\nBarbeiro ativado com sucesso!");
                        break;
                    case 2:
                        barbeiro.Ativo = false;
                        Console.WriteLine("\nBarbeiro desativado com sucesso!");
                        break;
                    case 3:
                        barbeiros.Remove(barbeiro);
                        Console.WriteLine("\nBarbeiro excluído com sucesso!");
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida."); 
                        break;
                }
            }
            
        static void AgendarHorario()
            {
                Console.WriteLine("\n--- Agendamento de Horário ---");
                // Aqui você pode adicionar a lógica para agendar um horário.
            }

        
    }
}