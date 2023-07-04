import {
  Button,
  Stack,
  CheckIcon,
  ColorSwatch,
  Group,
  TextInput,
  rem,
  useMantineTheme,
} from "@mantine/core";
import { HubConnection } from "@microsoft/signalr";
import { t } from "i18next";
import { useState } from "react";
import { User } from "../Shared/Interfaces/User";

interface EditUserProps {
  onSave: () => void;
  // TODO: Use Context for these?
  connection: HubConnection;
  user: User;
}

export const EditUser = ({ connection, user, onSave }: EditUserProps) => {
  const [initials, setInitials] = useState(user.initials);
  const [avatarColor, setAvatarColor] = useState(user.avatarColor);

  const theme = useMantineTheme();

  const updateInitials = () => {
    connection?.invoke("UpdateUser", { ...user, initials, avatarColor });
    onSave();
  };

  // TODO: Put the modal in here to simplify the calling signature?
  return (
    <Stack>
      <TextInput
        placeholder="Starting letters of your name, without spaces"
        label="Your initials"
        withAsterisk
        value={initials}
        minLength={2}
        maxLength={2}
        onChange={event =>
          setInitials(event.currentTarget.value.toLocaleUpperCase())
        }
        pb="sm"
      />
      <Group position="center" spacing="xs">
        {Object.keys(theme.colors).map(color => (
          <ColorSwatch
            key={color}
            component="button"
            color={theme.colors[color][6]}
            onClick={() => setAvatarColor(color)}
            sx={{ color: "#fff", cursor: "pointer" }}
          >
            {color == avatarColor && <CheckIcon width={rem(10)} />}
          </ColorSwatch>
        ))}
      </Group>
      <Button onClick={updateInitials}>{t("apply-changes")}</Button>
    </Stack>
  );
};
