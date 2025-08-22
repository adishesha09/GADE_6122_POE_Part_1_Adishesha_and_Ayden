# GADE 6122 POE Part 1 Development Process

## Project Overview
**Game Title:** CODE CRAWLER  
**Developers:** Adishesha Sai Nandkoomar & Ayden Graham Willett  
**Repository:** [GitHub Link](https://github.com/adishesha09/GADE_6122_POE_Part_1_Adishesha_and_Ayden)  
**Academic Institution:** Independent Institute of Education  
**Module:** Game Development (GADE 6122)  

---

## Development Timeline

### Phase 1: Foundation Setup
- **Initial Repository Setup:** Created GitHub repository with proper `.gitattributes` and `.gitignore` configurations  
- **Project Structure:** Established Visual Studio solution with appropriate naming conventions  
- **Core Classes Implementation:**  
  - `Position.cs`: Basic XY coordinate system implementation  
  - `Tile.cs`: Abstract base class for all game tiles  
  - `EmptyTile.cs`: Walkable space representation  
  - `WallTile.cs`: Boundary implementation with character `█`  

### Phase 2: Game Engine Core 
- **Level Management:**  
  - `Level.cs`: Implemented 2D tile array management with random map generation  
  - Dynamic sizing between `MIN_SIZE (10)` and `MAX_SIZE (20)` parameters  
  - Tile swapping functionality for character movement  
- **Character System:**  
  - `CharacterTile.cs`: Abstract base class with combat system and vision array  
  - `HeroTile.cs`: Player character with 40 HP and 8 attack power  
  - Vision system implementation for directional awareness  
- **Game Engine:**  
  - `GameEngine.cs`: Main game logic controller with state management  
  - Multi-level progression system (10 levels)  
  - Random level generation with size variation  

### Phase 3: User Interface & Polish 
- **Main Form Implementation:**  
  - `MainForm.cs`: Primary game interface with keyboard controls (WASD/Arrow keys)  
  - Monospaced font (Consolas) for proper grid alignment  
  - Real-time display updates  
- **Arcade Aesthetics:**  
  - `CRTEffectPanel.cs`: Custom panel with scanlines and vignette effects for authentic CRT appearance  
  - Black and green color scheme matching classic arcade cabinets  
  - `ArcadeSounds.cs`: Beep-based sound effects for game events  

### Phase 4: Enhanced Features 
- **Title Screen Implementation:**  
  - `TitleScreen.cs`: Professional introduction with blinking "PRESS ANY KEY" text  
  - Shadow effects and arcade-style typography  
  - Smooth transition to main game  
- **Audio Integration:**  
  - `SimpleMusicPlayer.cs`: Background music system using `System.Media.SoundPlayer`  
  - Music Credit: Background tracks by moodmode from Pixabay (Arcade Music Collection)  
  - WAV format compatibility with automatic looping  
- **Game Completion:**  
  - Exit tile implementation for level progression  
  - Game state management (`InProgress`, `Complete`, `GameOver`)  
  - Restart functionality with any-key support  

---

## Technical Architecture

### Core Game Classes
```
Position → Tile → EmptyTile/WallTile/ExitTile
           ↓
      CharacterTile → HeroTile
           ↓
         Level → GameEngine
```

### UI Layer
```
Program → TitleScreen → MainForm → CRTEffectPanel
```

### Audio System
```
SimpleMusicPlayer (Background music)
ArcadeSounds (Sound effects)
```

---

## Development Methodology

### Version Control Strategy
- Regular Commits: Frequent commits with descriptive messages  
- Branch Management: Main branch protection with feature-based development  
- Collaborative Development: Pair programming with clear responsibility division  

### Code Quality Standards
- OOP Principles: Strict adherence to encapsulation, inheritance, and polymorphism  
- Documentation: Comprehensive XML comments and inline documentation  
- Error Handling: Robust exception handling throughout the application  

### Testing Approach
- Incremental Testing: Each class tested immediately after implementation  
- Integration Testing: Regular full-game testing after major features  
- User Testing: Continuous gameplay testing for mechanics and UX  

---

## Challenges Overcome
- Movement System: Initial issues with tile swapping and vision array updates  
- Rendering Hierarchy: CRT effect integration with existing form controls  
- Audio Implementation: Finding simple, dependency-free music solution  
- Size Management: Ensuring no visual overflow with dynamic level sizes  

---

## Acknowledgments
- **Audio Assets:** Background music provided by moodmode from Pixabay (Arcade Music Collection) under Pixabay Content License  
- **Technical Assistance:** DeepSeek AI (v3) for consultation on CRT effect implementation and animation systems  
- **Academic Support:** GADE 6122 module guidelines and rubric requirements  

---

## Repository Structure
The project maintains a well-organized structure with clear separation of concerns:
<<<<<<< HEAD
=======
- Core game logic in `/GameCore` classes  
>>>>>>> b30a68d11846f41f20bba43692c3fec2ffb26885
- UI implementation in Windows Forms  
- Assets organized in `/music` directory  
- Comprehensive documentation throughout  

---

## Future Enhancements
This implementation provides a solid foundation for Parts 2 and 3 of the POE, which will include:
- Enemy character implementation  
- Combat system expansion  
- Item pickups and health system  
- Advanced saving/loading functionality  

The project successfully demonstrates object-oriented programming principles while delivering an engaging arcade-style gaming experience.
