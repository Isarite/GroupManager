using System;
using System.ComponentModel.DataAnnotations;


/**
 * @(#) Protocol.cs
 */

namespace Invensa.Models
{
	public class Protocol
	{
		DateTime Date;
		
		Boolean Quorum;
		
		Participant participant;
		
		Solution solutions;
		
		Question questions;
		
	}
	
}
