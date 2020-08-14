using ChatGrpc.Models;

namespace ChatGrpc.Providers
{
	public interface IChatRoomProvider
	{
		ChatRoom GetFreeChatRoom();
		ChatRoom GetChatRoomById(int roomId);
		ChatRoom AddChatRoom();
	}
}
