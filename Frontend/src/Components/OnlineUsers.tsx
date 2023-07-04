import styled from "@emotion/styled";
import { Padding } from "./Padding";
import { useEffect, useState } from "react";
import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from "@microsoft/signalr";
import { Avatar, Button, Group, Tooltip, useMantineTheme } from "@mantine/core";
import { useLocalStorage } from "@mantine/hooks";
import { User } from "../Shared/Interfaces/User";

// TODO: Use context to avoid context drilling
export const OnlineUsers = ({ usersOnline }: { usersOnline: User[] }) => {
  // const [user, setUser] = useLocalStorage<User | undefined>({
  //   key: "user",
  // });
  // const [initials] = useLocalStorage({
  //   key: "initials",
  // });
  // const [avatarColor] = useLocalStorage({
  //   key: "avatar-color",
  //   defaultValue: colors[Math.random() * colors.length],
  // });

  return (
    <StyledOnlineUsers>
      <Padding>
        <Avatar.Group spacing="xs">
          {usersOnline.map(user => (
            <Tooltip label={user.id}>
              <Avatar
                key={user.id}
                size="sm"
                radius="xl"
                color={user.avatarColor}
              >
                {user.initials}
              </Avatar>
            </Tooltip>
          ))}
        </Avatar.Group>
      </Padding>
    </StyledOnlineUsers>
  );
};

const StyledOnlineUsers = styled.div`
  position: absolute;
  right: 0;
  top: 0;
`;
