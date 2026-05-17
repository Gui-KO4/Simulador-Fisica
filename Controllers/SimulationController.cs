public class SimulationController
{
    private ProjectController projectController;

    public SimulationController(ProjectController projectController)
    {
        this.projectController = projectController;
    }

    // Executa a Simulação Cinemática (SMC) - Todas as partículas
    public void SMC(string durationStr, string stepStr)
    {
        Project active = this.projectController.GetActiveProject();
        if (!OutputView.ValidateTime(active, durationStr, stepStr, out double duration, out double step))
        {
            return;
        }

        if (active.particles.Count == 0) {
            Console.WriteLine("Nenhuma partícula registada.");
            return;
        }

        Console.WriteLine("Simulação cinemática iniciada.");
        Simulation(active, null, duration, step, true);
        Console.WriteLine("Simulação cinemática concluída.");
    }

    // Executa a Simulação Dinâmica (SMD) - Apenas uma partícula alvo
    public void SMD(string target, string durationStr, string stepStr)
    {
        Project active = this.projectController.GetActiveProject();
        if (!OutputView.ValidateTime(active, durationStr, stepStr, out double duration, out double step))
        {
            return;
        }

        if (!active.particles.ContainsKey(target))
        {
            Console.WriteLine($"Particula {target} não encontrada.");
            return;
        }

        Console.WriteLine("Simulação dinâmica iniciada.");
        Simulation(active, target, duration, step, false);
        Console.WriteLine("Simulação dinâmica concluída.");
    }

    private void Simulation(Project proj, string target, double duration, double step, bool isKinematic)
        {
            int iteracoes = (int)Math.Floor(duration / step);
            // Utiliza OutputView em vez de SimulationView
            OutputView.SimulationSummary(duration, step, iteracoes, target);

            for (double t = 0; t <= duration; t = Math.Round(t + step, 2))
            {
                OutputView.SimulationTime(t);

                foreach (var particle in proj.particles.Values)
                {
                    if (!isKinematic && particle.name != target) continue;

                
                    Force fRes = PhysicEngine.GetResultantForce(particle, proj.gravity);
                    var accDasForcas = PhysicEngine.GetAcceleration(fRes, particle.mass);

                    double accFinalX = particle.accelerationX + accDasForcas.x;
                    double accFinalY = particle.accelerationY + accDasForcas.y;

                    double accMostrarX = (t == 0) ? particle.accelerationX : accFinalX;
                    double accMostrarY = (t == 0) ? particle.accelerationY : accFinalY;

                    double posx = PhysicEngine.CalculatePos(particle.initialPositionX, particle.initialVelocityX, accFinalX, t);
                    double posy = PhysicEngine.CalculatePos(particle.initialPositionY, particle.initialVelocityY, accFinalY, t);

                    double distIntervalo = 0;
                    if (t > 0)
                    {
                        double tAnterior = Math.Round(t - step, 2);
                        double oldX = PhysicEngine.CalculatePos(particle.initialPositionX, particle.initialVelocityX, accFinalX, tAnterior);
                        double oldY = PhysicEngine.CalculatePos(particle.initialPositionY, particle.initialVelocityY, accFinalY, tAnterior);
                        distIntervalo = PhysicEngine.Distance(oldX, oldY, posx, posy);
                    }

                    double velx = PhysicEngine.CalculateVel(particle.initialVelocityX, accFinalX, t);
                    double vely = PhysicEngine.CalculateVel(particle.initialVelocityY, accFinalY, t);
                    
                    double distTotal = PhysicEngine.Distance(particle.initialPositionX, particle.initialPositionY, posx, posy);
                    OutputView.SimulationParticle(particle.name, posx, posy, velx, vely, accMostrarX, accMostrarY, isKinematic, distTotal, distIntervalo, fRes);
            }
        }
    }
}