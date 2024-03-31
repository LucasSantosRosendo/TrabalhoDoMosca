using System;

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

class Program {
    static void Main(string[] args) {
        Livro[] livros = new Livro[5];

        
        livros[0] = new Livro("1. Diário de um Banana 1");
        livros[1] = new Livro("2. Harry Potter e o Cálice de Fogo");
        livros[2] = new Livro("3. Percy Jackson e o Ladrão de Raios");
        livros[3] = new Livro("4. A Guerra dos Tronos");
        livros[4] = new Livro("5. Max e os felinos");

        
        Console.WriteLine("Livros disponíveis para empréstimo:");

        foreach (Livro livro in livros) {
            Console.WriteLine(livro.Nome);
        }
    }
}
