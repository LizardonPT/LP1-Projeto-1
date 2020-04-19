# Projeto 1 (Wolf and Sheep game)

## Índice:

- [Autores:](#autores)
- [Arquitetura da solução:](#arquitetura-da-solu%c3%a7%c3%a3o)
- [Referências:](#refer%c3%aancias)

### Autores:
**Este trbalho foi realizado por:**
- João Gonçalves, a21901696
- Vasco Duarte, a21905658

**Trabalho feito por cada aluno:**
- João Gonçalves: Inicializou o tabuleiro para que se pudesse gravar as casas onde estavam as peças. Fez o código para o jogador escolher onde quer que o lobo começe. Fez o método para o jogador poder escolher qual ovelha jogar. Fez o método do movimento das ovelhas, juntou o trabalho feito nos 2 branches diferentes ("apprentice" e "Movimento"). Atualizou os comentários, ajustou os textos todos para lingua inglesa e deu push para o branch "master". Ajustou todo o código para que não passasse dos 80 caracteres por linha. Adicionou comentários em XML e fez o relatório.
   
- Vasco Duarte: Fez o método para o movimento do lobo. Fez o código para as condições de ganhar ou perder o jogo. Fez o método que desenha gráficamente o tabuleiro e atualiza a cada jogada feita. Fez o menu de jogo com as opções de "Start", "Rules" e "Quit". Adicionou os últimos comentários ao código e fez o fluxograma.
  
- Nota: Apesar de termos dividido o trabalho desta maneira, o trabalho de cada aluno foi acompanhado na totalidade pelo seu colega de grupo, possibilitando assim a ajuda do colega quando necessário.

[Repositório Git online aqui](https://github.com/LizardonPT/LP1-Projeto-1)

### Arquitetura da solução:
O programa é inicializado com um ciclo while que mostra o menu de jogo ao jogador, esse menu tem 3 opções, "Start", "Rules" e "Quit". Caso o jogador escreva "Rules" irá aparecer as regras do jogo. O jogador pode abandonar o jogo a qualquer altura se escrever "Quit". Caso o jogador Escreva "Start", o jogo começa.

É criado o tabuleiro e de seguida o jogador que será o lobo terá de escolher, de entre as opções dadas, qual casa do tabuleiro quer começar. Se for dada uma resposta inválida o jogador terá de escrever novamente até se obter uma opção válida.

Quando tal acontecer, as ovelhas são colocadas no tabuleiro nas respectivas casas e é a vez do lobo jogar. Será apresentado no ecrã o tabuleiro com as peças, as coordenadas da posição atual do lobo e as escolhas possiveis de movimento para o mesmo. O jogo só avança quando o lobo fizer uma escolha válida. Este processo é feito atravéz do metodo "WolfMovement". Após o lobo jogar, é mostrado o tabuleiro atualizado e as coordenadas atualizadas.

De seguida são as ovelhas a jogar, primeiro o jogador terá de escolher qual ovelha jogar e para isso o programa vai buscar o método "ChoseSheep", que dirá como escolher a ovelha. Se o jogador escolher uma ovelha que esteja bloqueada, perde a sua vez e passa o turno. Quando é escolhida a ovelha é chamado o método "Sheepmovement" que vai depender da escolçha feita em "ChoseSheep"(ou seja, os movimentos possiveis vão mudar consoante a escolha de ovelha). Aqui o mesmo aconteçe com o lobo, é mostrado no ecrã as atualizações feitas após a jogada.

O jogo vai entrar num loop entre "WolfMovement", "ChoseSheep" e "Sheepmovement". Neste loop, a cada jogada feita é sempre mostrado no ecrã o tabuleiro atualizado(chama o método "Board") e as coordenadas atualizadas das peças respectivas. No loop, a cada jogada feita é também sempre verificado se o lobo chega à linha 7(caso aconteça ganha) ou se não tem para onde ir(caso aconteça perde). Se alguma destas 2 condições acontecer o jogo acaba e é declarado o vencedor.

**Fluxograma**

![alt text](https://cdn.discordapp.com/attachments/701504152378933279/701512504685101126/Untitled_Diagram.png)

### Referências:
1. Utilização da função "ref" para guardar as atualizações das posições no método "Main". [StackOverflow](https://stackoverflow.com/questions/40873556/editing-injected-parameter-without-returning-value-c-sharp?noredirect=1&lq=1)