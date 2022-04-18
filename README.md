# DesignPatternsNet6

## Behavioral Desing Patterns

### Strategy Desing Pattern
- Run Time esnasında bir objenin davranışını değiştirmemize imkan verir.
- Consumer'lara Run Time esnasında strategy (algorithm) seçmelerine imkan tanır.
- Compile Time esnasında klasik IoC DI container ile yapılanını dinamik şekilde Run Time esnasında yapılır.

### Template Desing Pattern
- Algoritmaları kapsüllememize soyutlamamıza imkan verir.
- Bir algoritmanın iskeleti tanımlanır ve bu iskeletin bazı adımlarının subclass'lar tarafından oluşturulması sağlanır.

### Command Desing Pattern
- Method çağırma işlemini kapsüller.

### Observer Desing Pattern
- Objeler arasında bire-çok bir ilişki tanımlanır.
- Bir objenin durumu değiştiğinde, bütün ilişkili olduğu objeler bilgilendirilir.
- Loosely coupled

### Chain of Responsibility Desing Pattern
- Sorumluluk zinciri oluşturur.
- Birbirini takip eden işleri ya handle eder yada zincirdeki bir sonraki halkaya gönderir.