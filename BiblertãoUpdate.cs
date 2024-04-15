using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
class Livro {
    public string Nome { get; set; }

    public Livro(string nome) {
        Nome = nome;
    }
}

class Usuario {
    public string Email { get; set; }
    public string Senha { get; set; }
    public string SenhaHash { get; private set;}

    public Usuario(string email, string senha) {
        Email = email;
        Senha = senha;
        SenhaHash = HashSenha(senha);
    }

    public string HashSenha(string senha) {
        using (SHA256 sha256Hash = SHA256.Create()) {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes) {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public void RedefinirSenha(string novaSenha) {
        Senha = novaSenha;
        SenhaHash = HashSenha(novaSenha);
    }
}

class Biblioteca {
    private List<Livro> livros = new List<Livro>();
    private List<Livro> livrosLidos = new List<Livro>();
    private List<Usuario> usuariosCadastrados = new List<Usuario>();
    private Usuario usuarioLogado;

    public Biblioteca() {
        livros.Add(new Livro("Diário de um Banana 1"));
        livros.Add(new Livro("Harry Potter e o Cálice de Fogo"));
        livros.Add(new Livro("Percy Jackson e o Ladrão de Raios"));
        livros.Add(new Livro("A Guerra dos Tronos"));
        livros.Add(new Livro("Max e os felinos"));
    }

    public void CriarConta() {
        string senha = "a", confirmarSenha = "b";
        do {
        Console.WriteLine("=== Cadastro do Biblertão ===");
        Console.WriteLine("Email obrigatório outlook!");
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Senha: ");
        senha = Console.ReadLine();
        Console.Write("Confirmar senha: ");
        confirmarSenha = Console.ReadLine();

        if (senha == confirmarSenha) {
            usuarioLogado = new Usuario(email, senha);
        usuariosCadastrados.Add(usuarioLogado);
        Console.WriteLine("Conta criada com sucesso!");
        Console.WriteLine($"Senha criptografada: {usuarioLogado.SenhaHash}");
    } else {
        
        Console.WriteLine("As senhas não compactuam!");
        
    }
        } while (senha != confirmarSenha);
    }

    public void Login() {
        bool loginSucesso = false;
        do {
            Console.WriteLine("=== Login === ");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (usuarioLogado != null && usuarioLogado.Email == email && usuarioLogado.Senha == senha) {
                Console.WriteLine("Login bem-sucedido!");
                loginSucesso = true;
                Menu();
            } else {
                Console.WriteLine("Email ou senha incorretos. Tente novamente.");
            }
        } while (!loginSucesso);
    }
    
    public void RedefinirSenha() {
        Console.WriteLine("=== Redefinir Senha === ");
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Usuario usuario = usuariosCadastrados.FirstOrDefault(u => u.Email == email);
        if (usuario != null) {
            string novaSenha = NovaSenha();
            usuario.RedefinirSenha(novaSenha);
            EnviarSenha(usuario.Email, novaSenha);
           Console.WriteLine("Senha redefinida com sucesso! Verifique seu email para a nova senha.");
        } else {
            Console.WriteLine("Email não encontrado.");
        }
    }

    private string NovaSenha() {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    static void EnviarSenha(string destinatario, string novaSenha)
    {
        string remetente = "TrabalhoMosca34@outlook.com";
        string assunto = "Redefinir senha - Biblertão";
        string corpo = $"Sua nova senha é: {novaSenha}";
        
        MailMessage mensagem = new MailMessage(remetente, destinatario, assunto, corpo);
        
        SmtpClient cliente = new SmtpClient("smtp-mail.outlook.com", 587);
        cliente.Credentials = new NetworkCredential(remetente, "TrabalhoMosca34");
        cliente.EnableSsl = true;
        
        try 
        {
            cliente.Send(mensagem);
            Console.WriteLine("Email enviado com sucesso!");
        }
        catch (Exception)
        {
            Console.WriteLine("ERR0: Erro ao enviar o email.");
        }
    }

    public void EmprestarLivro() {
        Console.WriteLine("Livros disponíveis para empréstimo:");
        for (int i = 0; i < livros.Count; i++){
            Console.WriteLine($"{i + 1}. {livros[i].Nome}");
        }
         Console.WriteLine("Digite o número correspondente ao título do livro a ser emprestado:");
        int numero = int.Parse(Console.ReadLine()) - 1;
        if (numero >= 0 && numero < livros.Count) {
            Livro livroEmprestado = livros[numero];
            livros.RemoveAt(numero);
            livrosLidos.Add(livroEmprestado);
            Console.WriteLine($"Você emprestou o livro {livroEmprestado.Nome} com sucesso. Boa leitura!");
        } else {
            Console.WriteLine("Opção inválida.");
        }
    }
    
    public void DevolverLivro() {
        Console.WriteLine("Livros disponíveis para devolução:");
        for (int i = 0; i < livrosLidos.Count; i++) {
            Console.WriteLine($"{i + 1}. {livrosLidos[i].Nome}");
        }
        Console.WriteLine("Digite o número correspondente ao título do livro a ser devolvido:");
        int numero = int.Parse(Console.ReadLine()) - 1;
        if (numero >= 0 && numero < livrosLidos.Count) {
            Livro livroDevolvido = livrosLidos[numero];
            livrosLidos.RemoveAt(numero);
            livros.Add(livroDevolvido);
            Console.WriteLine($"Você devolveu o livro {livroDevolvido.Nome} com sucesso!");
        } else {
            Console.WriteLine("Opção inválida.");
        }
    }
    
    public void ListarLivrosLidos() {
        Console.WriteLine("Livros lidos pelo aluno:");
        foreach (var livro in livrosLidos) {
            Console.WriteLine(livro.Nome);
        }
    }
    
    public void MarcarLivroLido() {
        Console.WriteLine("Livros disponíveis para marcar como lido:");
        for (int i = 0; i < livros.Count; i++) {
            Console.WriteLine($"{i + 1}. {livros[i].Nome}");
        }
        
        Console.WriteLine("Digite o número correspondente ao título do livro a ser marcado como lido:");
        int numero = int.Parse(Console.ReadLine()) - 1;
        
        if (numero >= 0 && numero < livros.Count) {
            Livro livroLido = livros[numero];
            livros.RemoveAt(numero);
            livrosLidos.Add(livroLido);
            Console.WriteLine($"Você marcou o livro {livroLido.Nome} como lido com sucesso!");
        } else {
            Console.WriteLine("Opção inválida.");
        }
    }
    
    public void MarcarProximaLeitura() {
        Console.WriteLine("Digite o número correspondente ao título do próximo livro a ser lido:");
        for (int i = 0; i < livros.Count; i++) {
            Console.WriteLine($"{i + 1}. {livros[i].Nome}");
        }
        
        int numero = int.Parse(Console.ReadLine()) - 1;
        
        if (numero >= 0 && numero < livros.Count) {
            Console.WriteLine($"O livro {livros[numero].Nome} foi marcado como próxima leitura com sucesso!");
        } else {
            Console.WriteLine("Opção inválida.");
        }
    }

    public void Menu() {
        int opcao;
        do {
            Console.WriteLine("=== Bem-vindo ao Biblertão ===");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Emprestar um livro");
            Console.WriteLine("2. Devolver um livro");
            Console.WriteLine("3. Listar livros lidos");
            Console.WriteLine("4. Marcar livro como lido");
            Console.WriteLine("5. Marcar como próxima leitura");
            Console.WriteLine("6. Redefinir senha");
            Console.WriteLine("7. Sair");
            Console.WriteLine("Escolha uma opção:");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    EmprestarLivro();
                    break;
                case 2:
                    DevolverLivro();
                    break;
                case 3:
                    ListarLivrosLidos();
                    break;
                case 4:
                    MarcarLivroLido();
                    break;
                case 5:
                    MarcarProximaLeitura();
                    break;
                case 6:
                    RedefinirSenha();
                    break;
                case 7:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 7);
    }
}

class Program {
    static void Main(string[] args) {
        Biblioteca biblioteca = new Biblioteca();

        int opcao;
        do {
            Console.WriteLine("=== Bem-vindo ao Biblertão ===");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Criar conta");
            Console.WriteLine("2. Fazer login");
            Console.WriteLine("3. Sair");
            Console.WriteLine("Escolha uma opção:");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    biblioteca.CriarConta();
                    break;
                case 2:
                    biblioteca.Login();
                    break;
                case 3:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 3);
    }
}