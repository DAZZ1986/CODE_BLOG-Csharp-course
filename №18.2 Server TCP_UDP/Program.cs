using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CODE_BLOG__18._2_Server_TCP_UDP
{
    class Program
    {
        static void Main(string[] args)
        {

            #region TCP 
            /*
            const string ip = "127.0.0.1";  // создали адрес в сети
            const int port = 8080;          // создали адрес в сети

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // создали эндпоинт

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // создали сокет
            tcpSocket.Bind(tcpEndPoint);  // связали сокет и эндпоинт
            tcpSocket.Listen(5);    // поставили сокет в режим прослушивания

            while (true)
            {
                var listener = tcpSocket.Accept(); // добавили подсокет, в котором будем обрабатывать конкретного клиента.
                                                   // Тоесть этот подсокет создается под каждого отдельного клиента и после он уничтожается.
                                                   // Клиент пришел, создали listener данные обработали, отправили ответ, клиент ушел,
                                                   // уничтожили его и далее создаем для нового клиента.
                var buffer = new byte[256];   // это буффер куда будут приходить данные между сокетами, хранилище данных.
                var size = 0;                 // тут будет сохраняться кол-во реально полученных данных, тк сообщение может быть короче.
                var data = new StringBuilder(); // позволяет удобно форматировать строки.
                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));              // Тут мы кусками по 256 байт берем, перекодируем,
                            //добавляем в строку, и снова берем, перекодируем, добавляем в строку итд и так собираем все целиком сообщение.

                } while (listener.Available > 0); // тут нам нужно проверять условие что мы получили запрос.


                // и после этого в data у нас собирается все сообщение
                Console.WriteLine(data);    // TODO: check for .ToString()

                // и даем ответ
                listener.Send(Encoding.UTF8.GetBytes("Success."));

                // закрываем наше подключение, нашего listener
                listener.Shutdown(SocketShutdown.Both); // сначала выключили его
                listener.Close();                       // и тут после выключения закрываем

            }
            */
            #endregion




            #region UDP
            const string ip = "127.0.0.1";  // создали адрес в сети
            const int port = 8081;          // создали адрес в сети

            var udppEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // создали эндпоинт
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); // создали сокет

            udpSocket.Bind(udppEndPoint);  // теперь делаем связывание

            while (true) // все это положили в while (true) для того чтобы получать не одно сообщение, а много.
            {
                var buffer = new byte[256];   // это буффер куда будут приходить данные между сокетами, хранилище данных.
                var size = 0;                 // тут будет сохраняться кол-во реально полученных данных, тк сообщение может быть короче.
                var data = new StringBuilder(); // позволяет удобно форматировать строки.

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);//создали экземпляр адреса в который будут записаны данные, тк
                                                                           //у нас нет подключения точка точка, а нам необходимо сохранить
                                                                           //данные того кто к нам подключался, тоесть адрес клиента.
                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                // отправляем сообщение о успешности получении
                udpSocket.SendTo(Encoding.UTF8.GetBytes("Messege recived"), senderEndPoint);

                // теперь нужно закрыть подключение


                // теперь нужно вывести полученное сообщение
                Console.WriteLine(data);
            }

            #endregion


        }
    }
}
