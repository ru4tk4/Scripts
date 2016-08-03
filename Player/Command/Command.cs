using UnityEngine;
using System.Collections;

public interface Command {
	void enter(Input_Handler input);
	void execute();
	void exit();
}
