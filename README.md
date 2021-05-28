## Анализатор тональности текста
Программа - [анализатор тональности](https://ru.wikipedia.org/wiki/Анализ_тональности_текста) введенного текста, реализованный на языке C#. 
Программа определяет количество эмоционально окрашенных слов в тексте и его общую тональность - отношение автора текста к высказываемому.

Программа использует несколько библиотек [NuGet](https://www.nuget.org), в частности:
* [DeepMorphy](https://www.nuget.org/packages/DeepMorphy/) - морфологический анализатор русского языка
* [TensorFlowSharp](https://www.nuget.org/packages/TensorFlowSharp/) - сборка открытой системы машинного обучения TensorFlow специально под .NET
Чтобы установить пакеты, воспользуйтесь`nuget install packages.config`, следуя [этой инструкции](https://docs.microsoft.com/ru-ru/nuget/consume-packages/install-use-packages-nuget-cli)
