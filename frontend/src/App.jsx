import { useState, useEffect } from 'react';
import './App.css';

function App() {
    const [workouts, setWorkouts] = useState([]);
    const [stats, setStats] = useState(null);

    useEffect(() => {
        // 1. Pobieramy listę treningów
        fetch('https://localhost:7134/api/WorkoutSessions')
            .then(res => res.json())
            .then(data => setWorkouts(data))
            .catch(err => console.error('Błąd pobierania treningów:', err));

        // 2. Pobieramy nasze statystyki z Dashboardu!
        fetch('https://localhost:7134/api/Dashboard/stats')
            .then(res => res.json())
            .then(data => setStats(data))
            .catch(err => console.error('Błąd pobierania statystyk:', err));
    }, []);

    return (
        <div className="app-container">
            <header className="app-header">
                <h1>🏋️‍♂️ Workout Tracker Dashboard</h1>
                <p>Full-Stack .NET Core & React App</p>
            </header>

            {/* Sekcja Statystyk */}
            {stats && (
                <section className="stats-section">
                    <div className="stat-card">
                        <h3>Suma treningów</h3>
                        <p className="stat-value">{stats.totalWorkouts}</p>
                    </div>
                    <div className="stat-card highlight">
                        <h3>Przerzucony ciężar</h3>
                        <p className="stat-value">{stats.totalVolumeKg} kg</p>
                    </div>
                    <div className="stat-card">
                        <h3>Ostatni trening</h3>
                        <p className="stat-value">{stats.lastWorkout}</p>
                    </div>
                </section>
            )}

            {/* Sekcja Listy Treningów */}
            <section className="workouts-section">
                <h2>Twoja historia treningowa</h2>
                <div className="workouts-grid">
                    {workouts.map(workout => (
                        <div key={workout.id} className="workout-card">
                            <h3 className="workout-title">{workout.name}</h3>
                            <div className="workout-details">
                                <p>📅 <span>{new Date(workout.date).toLocaleDateString()}</span></p>
                                <p>🔢 <span>Ilość serii: {workout.sets ? workout.sets.length : 0}</span></p>
                            </div>
                        </div>
                    ))}
                </div>
            </section>
        </div>
    );
}

export default App;