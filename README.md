## Анализатор тональности текста
Программа - [анализатор тональности](https://ru.wikipedia.org/wiki/Анализ_тональности_текста) введенного текста, реализованный на языке C#. 
Программа определяет количество эмоционально окрашенных слов в тексте и его общую тональность - отношение автора текста к высказываемому.

В основе общего анализа тональности текста используется тональный словарь русского языка [КартаСловСент](https://github.com/dkulagin/kartaslov/tree/master/dataset/emo_dict)

Программа использует несколько библиотек [NuGet](https://www.nuget.org), в частности:
* [DeepMorphy](https://www.nuget.org/packages/DeepMorphy/) - морфологический анализатор русского языка
* [TensorFlowSharp](https://www.nuget.org/packages/TensorFlowSharp/) - сборка открытой системы машинного обучения TensorFlow специально под .NET


Чтобы установить пакеты, следуя [этой инструкции](https://docs.microsoft.com/ru-ru/nuget/consume-packages/install-use-packages-nuget-cli), воспользуйтесь

`nuget install packages.config`

---
Программа написана как весенняя практика 2 курса, ПО-91Б. ЮЗГУ, 2021
