using System.Text;
using Akelon.Task_2.Utils.DTOs;

namespace Akelon.Task_2.Presentation
{
    public static class MenuMessages
    {
        public static string Main => @"
Выберите действие:
1. Запрос на ввод пути до файла с данными
2. Вывод информации о клиентах по наименованию товара
3. Изменение контактного лица клиента
4. Определение золотого клиента
5. Выход";

        public static string EnterFilePath => "Введите путь до файла с данными:";
        public static string EnterMonth => "Введите номер месяца (Enter, чтобы пропустить)";
        public static string EnterYear => "Введите год (Enter, чтобы пропустить)";
        public static string GoldenClient(GoldenClientDto? goldenClient) => goldenClient == null ? "Золотой клиент не определен" : $"Золотой клиент: \n{goldenClient}";
        public static string EnterProductName => "Введите наименование товара";
        public static string EnterCompanyName => "Введите наименование организации";
        public static string EnterClientContactFullName => "Введите ФИО контактного лица";
        public static string Goodbye => "Приложение завершило работу";
        public static string ClientsWhoOrderedTargetProductNotFound(string product) => $"Клиенты не найдены (Товар: {product})";

        public static string ClientsWhoOrderedTargetProduct(IEnumerable<ClientByOrderedProductDto> clients)
        {
            var msg = new StringBuilder();
            foreach (var client in clients)
            {
                msg.Append(client);
                msg.Append("\n\n");
            }

            return msg.ToString();
        }
    }
}
