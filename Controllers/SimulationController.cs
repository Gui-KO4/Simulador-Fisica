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
        Project active = projectController.GetActiveProject();
        double duration = Convert.ToDouble(durationStr);
        double step = Convert.ToDouble(stepStr);
        if (!OutputView.ValidateTime(active, duration, step))
        {
            return;
        }
        if (!OutputView.SimulationCinematic(active))
        {
            return; 
        }
        Simulation(active, null, duration, step, true);
        OutputView.SimulationFim();
       
    }

    // Executa a Simulação Dinâmica (SMD) - Apenas uma partícula alvo
    public void SMD(string target, string durationStr, string stepStr)
    {
        Project active = projectController.GetActiveProject();
        double duration = Convert.ToDouble(durationStr);
        double step = Convert.ToDouble(stepStr);
        if (!OutputView.ValidateTime(active, duration, step))
        {
            return;
        }

        if (!OutputView.SimulationDynamic(active, target))
        {
            return;
        }
        Simulation(active, target, duration, step, false);
        OutputView.SimulationFim(target);
    }

    private void Simulation(Project proj, string target, double duration, double step, bool isKinematic)
        {
            int iteracoes = Convert.ToInt32(duration / step);
            
            OutputView.SimulationSummary(duration, step, iteracoes, target);

            for (double t = 0; t <= duration; t = Math.Round(t + step, 2))
            {
                OutputView.SimulationTime(t);

                foreach (var particle in proj.particles.Values)
                {
                    if (!isKinematic && particle.name != target) continue;

                
                    Force fRes = PhysicEngine.GetResultantForce(particle, proj.gravity);

                    double accDasForcasX = PhysicEngine.GetAccelerationX(fRes, particle.mass);
                    double accDasForcasY = PhysicEngine.GetAccelerationY(fRes, particle.mass);
                    var accDasForcas = new Force(accDasForcasX, accDasForcasY);

                    double accFinalX = particle.accelerationX + accDasForcasX;
                    double accFinalY = particle.accelerationY + accDasForcasY;

                    double accMostrarX, accMostrarY;

                    if (t == 0)
                    {
                        accMostrarX = particle.accelerationX;
                        accMostrarY = particle.accelerationY;
                    }
                    else
                    {
                        accMostrarX = accFinalX;
                        accMostrarY = accFinalY;
                    }

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