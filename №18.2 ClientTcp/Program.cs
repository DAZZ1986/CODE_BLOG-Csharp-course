using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CODE_BLOG__18._2_ClientTcp
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

            Console.WriteLine("Insert the messege (TCP):");
            var message = Console.ReadLine();   // создаем то что будем отправлять
            var data = Encoding.UTF8.GetBytes(message); // кодируем данные

            tcpSocket.Connect(tcpEndPoint); // теперь открываем сокет и делаем для этого сокета подключение
            tcpSocket.Send(data);  // отправляем сообщение

            // после отправки ожидаем ответ
            var buffer = new byte[256];   // это буффер куда будут приходить данные между сокетами, хранилище данных.
            var size = 0;                 // тут будет сохраняться кол-во реально полученных данных, тк сообщение может быть короче.
            var answer = new StringBuilder(); // позволяет удобно форматировать строки.


            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));                // Тут мы кусками по 256 байт берем, перекодируем,
                                                                                        //добавляем в строку, и снова берем, перекодируем, добавляем в строку итд и так собираем все целиком сообщение.

            } while (tcpSocket.Available > 0); // тут нам нужно проверять условие что мы получили запрос.

            Console.WriteLine(answer.ToString());
            
            //закрываемся
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
            */
            #endregion





            #region UDP
            /*
            const string ip = "127.0.0.1";
            const int port = 8082;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // создаем тот же ендпоинт
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  // создаем тот же сокет
            udpSocket.Bind(udpEndPoint);

            // и теперь создадим отправку сообщения с клиента
            while (true)
            {
                Console.WriteLine("Enter messege (UDP):");
                var messege = Console.ReadLine();

                //клиент будет работать на порту 8082 и будет отправлять на порт 8081
                var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(messege), serverEndPoint);
            }

            // теперь нам нужно прочитать ответ
            var buffer = new byte[256]; 
            var size = 0; 
            var data = new StringBuilder(); // это билдер который будет наши данные собирать

            // теперь делаем прослушивание
            EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);// сюда будет сохранен адрес клиента.
                                                                       // создали экземпляр листнера,  у нас нету подключения точка-точка,
                                                                       // как было с TCP. Нам необходимо сохранить куда то адрес подключения.
                                                                       // и соответственно мы его прослушиваем
            do
            {
                size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);

                // продолжаем получать данные через наш StringBuilder
                data.Append(Encoding.UTF8.GetString(buffer));
            } while (udpSocket.Available > 0);


            // и теперь выводим на консоль
            Console.WriteLine(data);

            Console.ReadLine();
            */
            #endregion








        }
    }
}
