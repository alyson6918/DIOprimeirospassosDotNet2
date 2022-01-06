using DIOPrimeirosPassosDotNet2;
String option = " ";
Aluno[] alunos = new Aluno[5];
var indiceAlunos = 0;
do{
    Console.WriteLine("\nInforme a opção desejada:\n1- Inserir um novo aluno\n2- Listar alunos \n3- Calcular media geral\n4- Sair do programa\n");
    option = Console.ReadLine();
    switch(option){
        case "1":
            Console.WriteLine("Informe o nome do aluno:");
            Aluno aluno = new Aluno();
            aluno.Name = Console.ReadLine();
            Console.WriteLine("Informe a nota do aluno:");
            if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                aluno.Nota = nota;
            } else 
                throw new ArgumentException("O valor da nota deve ser decimal.");
            alunos[indiceAlunos]=aluno;
            indiceAlunos++;
            break;

        case "2":
            foreach(var a in alunos)
                if(a != null)
                    Console.WriteLine($"Aluno:{a.Name} | Nota:{a.Nota}");
            break;
        case "3":
            decimal notaTotal = 0;
            var nrAlunos = 0;
            for(int i=0; i<alunos.Length; i++)
                if (alunos[i] != null){
                    notaTotal+= alunos[i].Nota; 
                    nrAlunos++;
                }
            decimal mediaGeral = notaTotal / nrAlunos;
            Conceito conceitoGeral;

            if(mediaGeral < 2)
                conceitoGeral = Conceito.E;
            else if(mediaGeral < 4)
                conceitoGeral = Conceito.D;
            else if(mediaGeral < 6)
                conceitoGeral = Conceito.C;
            else if(mediaGeral < 8)
                conceitoGeral = Conceito.B;
            else
                conceitoGeral = Conceito.A;


            Console.WriteLine($"Média dos alunos: {mediaGeral} | Conceito:{conceitoGeral}");
            break;
        case "4":
            break;
        default :
            throw new ArgumentOutOfRangeException();
    }
} while (option != "4");