# Kripta
Алгоритм работы функций.

Скитала 1:
Получаем в строки введённые данные(строка и ключ).
Идут проверки - на пустые поля(текст и ключ), на введённый ключ(если < 0, чтоб не был больше длины сообщения).
Начинается работа:
- вычислили число столбцов(длина/ключ(диам)), если не ровно, то добавляем один.
- идём по столбцам, и в каждом столбце по буквам. Если длина сообщения < (столбцы*диам), то не считываем больше.

Скитала 2:
Получаем в строки введённые данные(строка и ключ).
Идут проверки - на пустые поля(текст и ключ), на введённый ключ(если < 0, чтоб не был больше длины сообщения).
Начинается работа:
-определяем число столбцов.
-переводим string в char[], для перевода в массив.
-создаём двумерный массив[столбцыХдиам].
-идём по столбцам массива, по строкам. Если длина кончилась, то не пишем дальше.
-теперь считываем из массива:счётчик строки, в одну строку берём по букве из каждой строки массива проходя по столбцам.

Полибий 1:
Создаём 4 алфавита.
Считываем текст и ключ.
Создаём переменные для проверок и работы на данными.
Проерки: на пустые поля, далее проверяем чтоб ключ был из букв, ключ и текст были одного алфавита и регистра.
Начинается работа:
-берём каждую букву из строки и проверяем чтоб была буквой, если нет, то просто выводим.
-если буква, то создаём массив под таблицу шифрования, определяем его алфавит исходя из проведённой ранее проверки.
-определяем необходимый размер.
-объединяем ключ и алфавит в t и удаляем повторяющиеся символы.
-переписываем получившуюся строку в массив.
-определяем строку и столбец выбранной ранее буквы из строки.
-ищем в таблице выбранную букву и берём букву под ней; если нижняя или под ней ничего, то берём из первой строки.

Полибий 2:
Создаём 4 алфавита.
Считываем текст и ключ.
Создаём переменные для проверок и работы на данными.
Проерки: на пустые поля, далее проверяем чтоб ключ был из букв, ключ и текст были одного алфавита и регистра.
Начинается работа:
-берём каждую букву из строки и проверяем чтоб была буквой, если нет, то просто выводим.
-если буква, то создаём массив под таблицу шифрования, определяем его алфавит исходя из проведённой ранее проверки.
-определяем необходимый размер.
-объединяем ключ и алфавит в t и удаляем повторяющиеся символы.
-переписываем получившуюся строку в массив.
-определяем строку и столбец выбранной ранее буквы из строки.
-ищем в таблице выбранную букву и берём букву над ней; если над ней ничего, то берём из нижней строки.