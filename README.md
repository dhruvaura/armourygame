# armourygame type implementation that show some of SOLID principle practical usage.


 Demonstrate how to use SOLID principles in implementation.

1. Single Responsibility Principle (SRP) (USED IN implementation)
2. Open/Closed Principle (OCP) (NOT USED IN implementation)
3. Liskov Substitution Principle  (NOT USED IN implementation)
4. Interface Segregation Principle (USED IN implementation)
5. Dependency Inversion Principle (USED IN implementation)


Providing here One Example of each Solid Principle.


1. Single Responsibility Principle
   
   Each class should only have one responsibility or functionality. 
   By follow to SRP, you ensure that each class has a single focus, which makes the code easier to understand, maintain, and test.
   
    	````
    	public class PlayerController : MonoBehaviour
    	{
    		private PlayerInput playerInput;
    		private PlayerMovement playerMovement;
    		private PlayerHealth playerHealth;
    
    		void Start()
    		{
    			playerInput = GetComponent<PlayerInput>();
    			playerMovement = GetComponent<PlayerMovement>();
    			playerHealth = GetComponent<PlayerHealth>();
    		}
    
    		void Update()
    		{
    			Vector2 movementInput = playerInput.GetMovementInput();
    			playerMovement.Move(movementInput);
    
    			if (playerInput.IsAttackButtonPressed())
    			{
    				// Handle attack logic here
    				Debug.Log("Attack button pressed.");
    			}
    		}
    
    		public void TakeDamage(int damage)
    		{
    			playerHealth.TakeDamage(damage);
    		}
    	}
    
    
    	public class PlayerInput : MonoBehaviour
    	{
    		public Vector2 GetMovementInput()
    		{
    			float moveX = Input.GetAxis("Horizontal");
    			float moveY = Input.GetAxis("Vertical");
    			return new Vector2(moveX, moveY);
    		}
    
    		public bool IsAttackButtonPressed()
    		{
    			return Input.GetButtonDown("Fire1");
    		}
    	}
    	
    	
    	public class PlayerMovement : MonoBehaviour
    	{
    		public float speed = 5f;
    
    		public void Move(Vector2 input)
    		{
    			Vector3 move = new Vector3(input.x, input.y, 0) * speed * Time.deltaTime;
    			transform.Translate(move);
    		}
    	}
    
    	public class PlayerHealth : MonoBehaviour
    	{
    		public int health = 100;
    
    		public void TakeDamage(int damage)
    		{
    			health -= damage;
    			if (health <= 0)
    			{
    				Die();
    			}
    		}
    
    		void Die()
    		{
    			Debug.Log("Player died.");
    			// Handle player death, e.g., restart game, show game over screen
    		}
    	}
    
    	````
   	^ above each class has a single, well-defined responsibility, making the codebase easier to understand, maintain, and test. 

2. Open Close Principle (OCP)

	You should be able to add new functionality to a class without changing its existing code. This can typically be achieved through inheritance, interfaces, and abstraction. 
	By following OCP, you can extend a class's behavior without risking breaking the existing functionality.
   
    	```
	    	public abstract class Enemy : MonoBehaviour
	    	{
	    		public abstract void Attack();
	    	}
	    
	    	public class Dinosaur : Enemy
	    	{
	    		public override void Attack()
	    		{
	    			Debug.Log("Doblin attacks!");
	    		}
	    	}
	    
	    	public class Dragon : Enemy
	    	{
	    		public override void Attack()
	    		{
	    			Debug.Log("Dragon attacks!");
	    		}
	    	}
    	```
   
	Here, you can add new enemy types by extending the Enemy class without modifying it.
   

3. Liskov Substitution Principle (LSP)

   Subclasses should be able to substitute their parent classes without causing issues in the implementation. 
   This means that subclasses should extend the functionality of a superclass without changing its expected behavior.

    ```
	public abstract class Enemy : MonoBehaviour
	{
		public abstract void Attack();
		public virtual void Move()
		{
			Debug.Log("Enemy moves");
		}
	}
	
	public class Dinosaur : Enemy
	{
		public override void Attack()
		{
			Debug.Log("Dinosaur attacks!");
		}
	
		public override void Move()
		{
			Debug.Log("Dinosaur moves quickly");
		}
	}
	
	public class Dragon : Enemy
	{
		public override void Attack()
		{
			Debug.Log("Dragon attacks!");
		}
	
		// Dragon does not override Move, uses base implementation
	}
    ```

   Dinosaur and Dragon can replace Enemy without breaking the expected behavior.


4. Interface Segregation Principle (ISP)
	
     Separating features into different interfaces.

    	```
    	public interface IAttack
    	{
    		void Attack();
    	}
    
    	public interface IDefend
    	{
    		void Defend();
    	}
    
    	public class Warrior : MonoBehaviour, IAttack, IDefend
    	{
    		public void Attack()
    		{
    			Debug.Log("Warrior attacks!");
    		}
    
    		public void Defend()
    		{
    			Debug.Log("Warrior defends!");
    		}
    	}
    
    	public class Archer : MonoBehaviour, IAttack
    	{
    		public void Attack()
    		{
    			Debug.Log("Archer attacks from distance!");
    		}
    	}
    	```
	Warrior implements both IAttack and IDefend, while Archer only implements IAttack.
			

5. Dependency Inversion Principle (DIP)

    The Dependency Inversion Principle (DIP) helps create a flexible, decoupled, and maintainable codebase by ensuring that high-level modules depend on abstractions rather than concrete implementations.

    	```
    	public interface IWeapon
    	{
    		void Use();
    	}
    
    	public class Sword : MonoBehaviour, IWeapon
    	{
    		public void Use()
    		{
    			Debug.Log("Swinging sword");
    		}
    	}
    
    	public class Bow : MonoBehaviour, IWeapon
    	{
    		public void Use()
    		{
    			Debug.Log("Shooting arrow");
    		}
    	}
    
    	public class Player : MonoBehaviour
    	{
    		private IWeapon weapon;
    
    		public void EquipWeapon(IWeapon newWeapon)
    		{
    			weapon = newWeapon;
    		}
    
    		public void Attack()
    		{
    			if (weapon != null)
    			{
    				weapon.Use();
    			}
    			else
    			{
    				Debug.Log("No weapon equipped");
    			}
    		}
    	}
    	```
    
	Used an interface (IWeapon) to decouple the Player class from concrete weapon implementations (Sword, Bow).
    	High-Level Module: The Player class depends on the IWeapon interface rather than concrete weapon classes.
    	Low-Level Modules: The Sword and Bow classes implement the IWeapon interface.



	


