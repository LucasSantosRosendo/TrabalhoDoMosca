using System;
using System.Collections.Generic;

        class Livro {
    private string nome;

    public Livro(string nome) {
        this.nome = nome;
    }

    public string Nome {
        get {
            return nome;
        }
        set {
            nome = value;
        }
    }
}

class Biblioteca {
    private List<Livro> livros = new List<Livro>();
    private List<Livro> livrosLidos = new List<Livro>();

    public Biblioteca() {
        livros.Add(new Livro("1. Diário de um Banana 1"));
        livros.Add(new Livro("2. Harry Potter e o Cálice de Fogo"));
        livros.Add(new Livro("3. Percy Jackson e o Ladrão de Raios"));
        livros.Add(new Livro("4. A Guerra dos Tronos"));
        livros.Add(new Livro("5. Max e os felinos"));
    }

    public void EmprestarLivro() {
        
        Console.WriteLine("Livros disponíveis para empréstimo:");
        foreach (var livro in livros)
        Console.WriteLine(livro.Nome);{
        }
        Console.WriteLine("Digite o número correspondente ao título do livro a ser emprestado:");
        int titulo = int.Parse(Console.ReadLine());
        switch(titulo){
            case 1:
            Console.WriteLine($"Você escolheu o livro {livros[0].Nome} com sucesso. Boa leitura!");
            break;
            case 2:
            Console.WriteLine($"Você escolheu o livro {livros[1].Nome} com sucesso. Boa leitura!");
            break;
            case 3:
            Console.WriteLine($"Você escolheu o livro {livros[2].Nome} com sucesso. Boa leitura!");
            break;
            case 4:
            Console.WriteLine($"Você escolheu o livro {livros[3].Nome} com sucesso. Boa leitura!");
            break;
            case 5:
            Console.WriteLine($"Você escolheu o livro {livros[4].Nome} com sucesso. Boa leitura!");
            break;
            default:
            Console.WriteLine($"Você digitou um livro que não temos na biblioteca!");
            break;
        }
    }

    public void DevolverLivro() {
        Console.WriteLine("Livros disponíveis para devolução:");
        foreach (var livro in livros)
        Console.WriteLine(livro.Nome);{
        }
        Console.WriteLine("Digite o número correspondente ao título do livro a ser devolvido:");
        int devolver = int.Parse(Console.ReadLine());
        switch (devolver){
            case 1: 
            Console.WriteLine($"O livro {livros[0].Nome} foi devolvido com sucesso!");
            break;
            case 2:
            Console.WriteLine($"O livro {livros[1].Nome} foi devolvido com sucesso!");
            break;
            case 3:
            Console.WriteLine($"O livro {livros[2].Nome} foi devolvido com sucesso!");
            break;
            case 4:
            Console.WriteLine($"O livro {livros[3].Nome} foi devolvido com sucesso!");
            break;
            case 5:
            Console.WriteLine($"O livro {livros[4].Nome} foi devolvido com sucesso!");
            break;
            default:
            Console.WriteLine("Você digitou um número inválido!");
            break;
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
        foreach (var livro in livros)
        Console.WriteLine(livro.Nome);{
        }
        Console.WriteLine("Digite o número correspondente ao título do livro a ser marcado como lido:");
        int lido = int.Parse(Console.ReadLine());
        switch(lido){
            case 1: 
            Console.WriteLine($"O livro {livros[0].Nome} foi marcado como lido com sucesso!");
            break;
            case 2:
            Console.WriteLine($"O livro {livros[1].Nome} foi marcado como lido com sucesso!");
            break;
            case 3:
            Console.WriteLine($"O livro {livros[2].Nome} foi marcado como lido com sucesso!");
            break;
            case 4:
            Console.WriteLine($"O livro {livros[3].Nome} foi marcado como lido com sucesso!");
            break;
            case 5:
            Console.WriteLine($"O livro {livros[4].Nome} foi marcado como lido com sucesso!");
            break;
            default:
            Console.WriteLine("Você digitou um número inválido!");
            break;
        }
    }

    public void MarcarProximaLeitura() {
        Console.WriteLine("Digite o número correspondente ao título do próximo livro a ser lido:");
        int proximaleitura = int.Parse(Console.ReadLine());
        switch(proximaleitura){
            case 1: 
            Console.WriteLine($"O livro {livros[0].Nome} foi marcado como próxima leitura com sucesso!");
            break;
            case 2:
            Console.WriteLine($"O livro {livros[1].Nome} foi marcado como próxima leitura com sucesso!");
            break;
            case 3:
            Console.WriteLine($"O livro {livros[2].Nome} foi marcado como próxima leitura com sucesso!");
            break;
            case 4:
            Console.WriteLine($"O livro {livros[3].Nome} foi marcado como próxima leitura com sucesso!");
            break;
            case 5:
            Console.WriteLine($"O livro {livros[4].Nome} foi marcado como próxima leitura com sucesso!");
            break;
            default:
            Console.WriteLine("Você digitou um número inválido!");
            break;
        }
    }
    class Bertastro{
        public string email;
        private string senha;
        public bool cadastroCerto = false;
        
    public void Cadastro (){
        Console.WriteLine("Opções: ");
        Console.WriteLine("1. Logar");
        Console.WriteLine("2. Cadastro");
        int escolha = int.Parse(Console.ReadLine());
        switch(escolha){
            case 1: 
            Console.WriteLine("Email: ");
            string email2 = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            
            cadastroCerto = true;
            break;
            
            case 2:
            Console.WriteLine("Para iniciar o cadastro, digite as seguintes informações:");
            Console.Write("Email: ");
            email = Console.ReadLine();
            Console.Write("Senha: ");
            senha = Console.ReadLine();
            Console.Write("Confirme a sua senha: ");
            string senhaConfirmar = Console.ReadLine();
            if(senha == senhaConfirmar){
            Console.WriteLine("O seu cadastro foi realizado com sucesso!");
    
        }
        else {
            Console.WriteLine("ERR0: As senhas digitadas são diferentes!");
        
        }
        break;
        default:
        Console.WriteLine("Opção inválida!");
        break;
        }
    }
    }
    
    public void Menu() {
        int opcao;
        if (cadastroCerto) {
            do {
            Console.WriteLine("=== Bem-vindo ao Biblertão ===");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Emprestar um livro");
            Console.WriteLine("2. Devolver um livro");
            Console.WriteLine("3. Listar livros lidos");
            Console.WriteLine("4. Marcar livro como lido");
            Console.WriteLine("5. Marcar como próxima leitura");
            Console.WriteLine("6. Sair");
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
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 6);
    }
    }


class Program {
    static void Main(string[] args) {
        Biblioteca biblioteca = new Biblioteca();
        biblioteca.Menu();
    }
}
}