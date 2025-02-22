# Projeto realizado no curso de graduação de Ciência da Computação na UTFPR, para a disciplina de Padrões de Projeto Extensionista

https://github.com/YujiMekaru/scripts_mercadinho

- Os arquivos com o sufixo "Handler" são utilizados como "eventos" da interface gráfica. Por exemplo: Evento de Clique de um Botão, Evento do Carregamento de uma tela, etc.

- Os arquivos estão, em sua maioria, divididos por telas em que são executados.

- Os arquivos principais que gerenciam o estado do jogo e suas funcionalidades principais estão na pasta Game.

- Os Singletons estão em diversas partes do projeto.

- O padrão Strategy encontra-se na pasta FaseScene.

- O padrão Observer:
	- Sua interface está na pasta /Game/Interfaces
	- A interface é implementada nas classes: "ListRendererSingleton", "GameManagerSingleton.
	- A classe abstrata Subject está na pasta /Game/Models
	- Subject é herdada na classe /Game/Services/InventorySingleton

- O padrão Factory Method encontra-se na pasta CorredorScene
