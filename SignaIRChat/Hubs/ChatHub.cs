using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignaIRChat.Models;
using SignaIRChat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignaIRChat.Hubs
{
    public class ChatHub : Hub
    {
        //private readonly static ConnectionsRepository _connections = new ConnectionsRepository();

        private readonly ConnectionsRepository _repository;

        public ChatHub(ConnectionsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Override para inserir cada usuário no nosso repositório, lembrando que esse repositório está em memória
        /// </summary>
        /// <returns> Retorna lista de usuário no chat e usuário que acabou de logar </returns>
        public override Task OnConnectedAsync()
        {
            var user = JsonConvert.DeserializeObject<UserModel>(Context.GetHttpContext().Request.Query["user"]);
            //_connections.Add(Context.ConnectionId, user);
            ////Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
            //Clients.All.SendAsync("chat", _connections.GetAllUser(), user);

            _repository.Add(user);
            //Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
            Clients.All.SendAsync("chat", _repository.GetAllUser(), user);

            return base.OnConnectedAsync();
        }


        /// <summary>
        /// Método responsável por encaminhar as mensagens pelo hub
        /// </summary>
        /// <param name="ChatMessage">Este parâmetro é nosso objeto representando a mensagem e os usuários envolvidos</param>
        /// <returns></returns>
        public async Task SendMessage(MessageModel chat)
        {
            //Ao usar o método Client(_connections.GetUserId(chat.destination)) eu estou enviando a mensagem apenas para o usuário destino, não realizando broadcast
            await Clients.Client(_repository.GetUserId(chat.destination)).SendAsync("Receive", chat.sender, chat.message);
        }
    }
}
