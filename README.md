# Część I. Aplikacja konsolowa
### Stwórz w języku Python/C#/C++/Java działającą aplikację konsolową o nazwie Warcaby, zgodnie z następującymi wymaganiami: 
### Plansza: 
- Gra toczy się na standardowej planszy 8x8. 
### Pionki: 
- Używane są tylko pionki zwykłe (brak damki).
- Czarne pionki ('c') startują na górze (rzędy 0-2) i poruszają się tylko w dół. 
= Białe pionki ('b') startują na dole (rzędy 5-7) i poruszają się tylko w górę. 
### Ruch: 
- Pionki poruszają się na skos o jedno pole. 
### Bicie: 
- Bicie (skok o dwa pola na skos nad pionkiem przeciwnika) jest dozwolone. 
- UWAGA: W tej wersji bicie NIE JEST obowiązkowe, a po wykonaniu bicia następuje natychmiastowa zmiana tury (brak łańcuchów bić). 
### Interfejs Użytkownika: 
- Plansza musi być wyświetlana w konsoli po każdym ruchu, używając koordynat 0-7 dla wierszy i kolumn. 
- Aplikacja musi pobierać ruchy od gracza w formacie: r1,c1 na r2,c2 (np. 5,0 na 4,1). 
- Musi być weryfikowany, czy podany ruch jest legalny (zgodny z kierunkiem pionka, nie na zajęte pole, na skos). 
- Koniec Gry: Gra kończy się, gdy jeden z graczy straci wszystkie swoje pionki. 
 
### Założenia aplikacji: 
- Wyświetlanie graficznej planszy 8x8. 
- Obsługa  wyboru pionka i pola docelowego. 
- Zaimplementowanie tej samej, uproszczonej logiki gry . 
