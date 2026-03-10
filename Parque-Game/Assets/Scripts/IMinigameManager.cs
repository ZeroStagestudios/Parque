public interface IMinigameManager 
{
  int ticketsGanhos { get; set; }
  void vencerMinigame();
  void perderMinigame();
  void DadosMinigame();
}
