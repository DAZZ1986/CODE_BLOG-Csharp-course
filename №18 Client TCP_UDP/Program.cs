using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _18_ClientTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TCP
            /*
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // создаем тот же ендпоинт
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // создаем тот же сокет

            // и теперь создадим то что мы будем отправлять
            Console.WriteLine("Enter messege:");
            var messege = Console.ReadLine();   // получили сообщение от пользователя

            var data = Encoding.UTF8.GetBytes(messege);  // закодировали данные

            // теперь нужно открыть сокет, тоесть сделать подключение для этого сокета. На сервере мы сокет переводили в режим слушанья,
            // тк это сокет сервера он слушает, а тут сокет клиента, сразу делаем подключение.
            tcpSocket.Connect(tcpEndPoint);

            // теперь нам осталось только отправить сообщение
            tcpSocket.Send(data);

            // после отправки мы ожидаем ответ
            var buffer = new byte[256];   
            var size = 0; 
            var answer = new StringBuilder();   // тут получаем ответ

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); 
            }
            while (tcpSocket.Available > 0);

            // получили сообщение и теперь выведем его на консоль
            Console.WriteLine(answer.ToString());

            // и теперь нужно так же закрываться
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
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  // создаем тотже сокет
            udpSocket.Bind(udpEndPoint);

            // и теперь создадим отправку сообщения с клиента
            while (true)
            {
                Console.WriteLine("Enter messege:");
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
